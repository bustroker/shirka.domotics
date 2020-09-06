## Work in progress
This is just WIP. Can't run the voice fully from a container because no access to sound card from there. Need to figure out the cleanest way to do it.

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
Reproduce it from the host to listen to it.

### generate `wav` file manually in RPi
- build image
```
docker build -t voice .
```

- run and bash inside the container, mapping the folders where wav file is to be created.
```
docker run -it -v /home/shirka/shirka.domotics/voice/tts:/home/app voice bash
```

- generate `tts.wav` in the mapped folder, from inside the container
```
espeak -w tts.wav "Hello world"
```

- exit the container and from the RPi, test the generated file
```
omxplayer -o local tts.wav
```