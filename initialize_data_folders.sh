#!/bin/bash

mkdir data 
cd data 
mkdir grafana 
mkdir influxdb 
mkdir nodered
cd ..
cp nodered/data/* data/nodered
