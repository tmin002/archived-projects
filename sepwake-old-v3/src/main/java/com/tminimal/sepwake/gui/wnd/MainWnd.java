package com.tminimal.sepwake.gui.wnd;

import com.tminimal.sepwake.gui.MainPanel;

public class MainWnd extends Window {

    public MainWnd() {
        super("Main Window", new MainPanel(), 300, 300);
        this.setVisible(true);
    }
}
