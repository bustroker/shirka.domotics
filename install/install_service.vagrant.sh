#!/bin/bash
cp ./shirka_domotics.vagrant.service /etc/systemd/system/shirka_domotics.service
systemctl enable shirka_domotics.service
systemctl start shirka_domotics.service