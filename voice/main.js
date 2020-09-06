(function(){
    const exec = require("child_process").exec;
    
    var playFile = function(){
        exec("omxplayer -o local tts.wav");
    }

    var createOrOverrideTTSWav = function(){
        exec("espeak -w tts.wav -l \"Hello Cloe\"");
    }

    createOrOverrideTTSWav();
    playFile();
})();