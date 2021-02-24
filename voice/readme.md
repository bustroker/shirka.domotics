## Work in progress
This is just WIP. Can't run the voice fully from a container because no access to sound card from there. Need to figure out the cleanest way to do it.

https://stackoverflow.com/questions/41083436/how-to-play-sound-in-a-docker-container
https://blog.jessfraz.com/post/docker-containers-on-the-desktop/

### generate `wav` file manually in vagrant VM
- build image
```
docker build -t voice .
```

- run and bash inside the container, mapping the folders where wav file is to be created.
```
docker run -it -v /vagrant/voice/tts:/home/app voice bash
```

- generate `tts.wav` in the mapped folder, from inside the container
```
espeak -w tts.wav "Hello world"
```
tts.wav is generated in `/home/app` folder in the container, which is mapped to `/vagrant/voice/tts` folder in vagrant VM, which is in turn mapped to `shirka.domotics/voice/tts` folder in host.

Reproduce wav from VM
´´´

´´´

### generate `wav` file manually in RPi
- build image
```
sudo docker build -t voice .
```

- run and bash inside the container, mapping the folders where wav file is to be created, and attaching the host's sound device to the container.
```
sudo docker run -it -v /home/shirka/shirka.domotics/voice/tts:/home/app --device /dev/snd voice bash
```

- call tts
```
espeak "hello world"
```

- another choice, to generate `tts.wav` in the mapped folder, to reproduce later on
```
espeak -w tts.wav "Hello world"
```

- exit the container and from the RPi, test the generated file
```
sudo omxplayer -o local tts.wav
```