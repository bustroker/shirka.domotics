### Websockets
nodered uses a ws connection to test connectivity with server. To open this connection the following was added:
```
proxy_set_header Upgrade $http_upgrade;
proxy_set_header Connection "Upgrade";
proxy_set_header Host $host;
```