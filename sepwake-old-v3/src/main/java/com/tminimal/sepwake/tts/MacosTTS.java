package com.tminimal.sepwake.tts;

import com.tminimal.sepwake.d;
import java.io.IOException;

public class MacosTTS extends TTS {

    public String voiceName = "Yuna";

    @Override
    public void speak(String str) {
        try {
            Process say = Runtime.getRuntime().exec(new String[] { "say", "-v", voiceName, str });
            try {
                say.waitFor();
            } catch (InterruptedException e) {
                say.destroy();
            }
        } catch (IOException e) {
            d.s("Failed to initialize TTS.");
        }
    }
}
