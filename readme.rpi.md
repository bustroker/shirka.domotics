## install docker
```
curl -sSL https://get.docker.com | sh
sudo usermod -aG docker pi

sudo apt-get install -y libffi-dev libssl-dev
sudo apt-get install -y python3 python3-pip
sudo apt-get remove python-configparser

sudo pip3 -v install docker-compose
```

## create shirka user and add permissions on shirka folder
Create `shirka` user and add it to sudoers
```
sudo adduser shirka
```

Add full permissions over shirka folder, recursively
```
cd shirka
chmod -R 755
```