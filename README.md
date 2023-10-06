# RedisSampleApp

A sample application to demonstrate the integration of an app with Redis, both running on Kubernetes.

## Prerequisites

- Ensure you have Kubernetes installed and configured.
- Ensure you have `kubectl` installed and configured to communicate with your cluster.

## Deployment

### 1. Clone the Repository

Before deploying, ensure you have a local copy of the repository:

```bash
git clone https://github.com/tripvik/RedisSampleApp.git
cd RedisSampleApp
```

### 2. Deploy Redis on Kubernetes

Deploy the Redis service using the provided Kubernetes configuration:

```bash
kubectl apply -f redis-deployment.yml
```

Verify that the Redis pods are running:

```bash
kubectl get pods -l app=redis
```

### 3. Deploy the Application on Kubernetes

Once Redis is running, deploy the `RedisSampleApp` using its Kubernetes configuration:

```bash
kubectl apply -f app-deployment.yaml
```

Verify that the application pods are running:

```bash
kubectl get pods -l app=redis-sample-app
```

## Accessing the Application

Retrieve the external IP address with:

```bash
kubectl get svc redis-sample-app-service
```

Visit the external IP in your to interact with the application.
