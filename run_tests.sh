#!/bin/bash

cd Shirka.Domotics.Tests
sudo docker build -t tests .
REVERSE_PROXY_BASE_URL=http://localhost
REVERSE_PROXY_NODE_PORT=8080
REVERSE_PROXY_GRAFANA_PORT=9090
DIRECT_NODERED_PORT=1880 
DIRECT_GRAFANA_PORT=3000
sudo docker run --network host -e REVERSE_PROXY_BASE_URL=$REVERSE_PROXY_BASE_URL -e REVERSE_PROXY_NODE_PORT=$REVERSE_PROXY_NODE_PORT -e REVERSE_PROXY_GRAFANA_PORT=$REVERSE_PROXY_GRAFANA_PORT -e DIRECT_NODERED_PORT=$DIRECT_NODERED_PORT -e DIRECT_GRAFANA_PORT=$DIRECT_GRAFANA_PORT tests
