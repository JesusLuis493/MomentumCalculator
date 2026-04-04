// 1.- Configuracion global 
terraform {
  required_providers {
    google = {
      source = "hashicorp/google"
      version = "7.17.0"
    }
  }
}

// 2.- Configuracion del proveedor de Google Cloud
provider "google" {
  project = var.proyecto_id
  region = var.region
  zone = var.zona
}

// 3.- Variables de entrada
variable "proyecto_id" {
  description = "Inicializacion del  proyecto de GCP - Momentum calculator"
  type        = string
  default     = "Momentum-calc"
}

variable "repositorio_id" {
  description = "Clave id - repo - Momentum calculator"
  type = string
  default = "momentum-calc-2026"
}

variable "region"{
  description = "region de despliegue"
  type = string
  default = "us-central1"
}

variable "zona" {
  description = "inicializando zona de despliegue correcpondiente a la region"
  type = string
  default = "us-central1-c"
}

variable "app_puerto" {
  description = "Puerto de acceso para el contenedor mediante el servicio de Cloud Run"
  type        = number
  default     = 5227
}


// 4.- API recurso
resource "google_project_service" "API" {
  project = var.proyecto_id
  service = "run.googleapis.com"
  disable_on_destroy = false
}
resource "google_project_service" "artifact_registry_api" {
  project = var.proyecto_id
  service = "artifactregistry.googleapis.com"
  disable_on_destroy = false
}

// 5.- Infraestructura de docker
resource "google_artifact_registry_repository" "docker_container" {
  location      = var.region
  repository_id = var.repositorio_id
  description = "Define un repositorio en GCP con el formato DOCKER para almacenar imágenes de contenedores"
  format        = "DOCKER"

  depends_on = [google_project_service.artifact_registry_api]
}

// 6.- Cloud Run recurso
resource "google_cloud_run_v2_service" "servidor_cloud" {
  name     = "cloud-run-srv"
  location = var.region

  template {
      containers{
        image = "${google_artifact_registry_repository.docker_container.repository_id}/momentum-calc:latest"

        ports {
          container_port = var.app_puerto
        }
      }
      scaling {
      min_instance_count = 0    # Se apaga cuando nadie la usa → $0
      max_instance_count = 2    # Tope para que no explote la factura
      } 
    }
  }

// 7.- Otuputs 
output "cloud_run_url" {
  description = "URL pública del servicio Cloud Run"
  value       = google_cloud_run_v2_service.servidor_cloud.uri
}

output "artifact_registry_repository" {
  description = "Ruta completa del repositorio Docker"
  value       = "${var.region}-docker.pkg.dev/${var.proyecto_id}/${google_artifact_registry_repository.docker_container.repository_id}"
}

output "proyecto_id" {
  description = "ID del proyecto GCP"
  value       = var.proyecto_id
}