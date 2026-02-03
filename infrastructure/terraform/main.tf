terraform {
  required_providers {
    google = {
      source = "hashicorp/google"
      version = "7.17.0"
    }
  }
}

provider "google" {
  project = "MomentumCalculator"
  region = "us-central1"
  zone = "us-central1-c"
}
