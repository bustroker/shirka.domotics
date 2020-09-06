## run manually in the RPi
- bash inside the container
```
docker run -it -v /vagrant/voice/tts:/home/app voice bash
```

- generate `tts.wav` in the mapped folder.
```
espeak -w tts.wav "Hello world"
```

- leave the container and from the vagrant vm, test the generated file
```
omxplayer -o local tts.wav
```