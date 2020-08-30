#!/bin/bash

mkdir data 
cd data 
mkdir grafana 
mkdir influxdb 
mkdir nodered
cd ..
cp nodered/initial_data/* data/nodered
