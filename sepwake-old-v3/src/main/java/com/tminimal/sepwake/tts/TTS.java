package com.tminimal.sepwake.tts;

public abstract class TTS {
    public abstract void speak(String str);

    public void speakAsync(String str) {
        new Thread(() -> this.speak(str)).start();
    }
}
