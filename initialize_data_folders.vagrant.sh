#!/bin/bash

cd ..
mkdir shirka.domotics.data 
cd shirka.domotics.data 
mkdir grafana 
mkdir influxdb 
mkdir nodered
cd ..
cp vagrant/nodered/initial_data/* shirka.domotics.data/nodered
cd shirka.domotics.data/nodered
git init
