package com.tminimal.sepwake.config;

import com.tminimal.sepwake.alarm.*;
import com.tminimal.sepwake.d;
import com.tminimal.sepwake.gui.msgbox.MsgBox;
import org.yaml.snakeyaml.DumperOptions;
import org.yaml.snakeyaml.Yaml;

import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;

public class ConfigSaver {
    private ConfigSaver() {}

    public static void saveConfig() {
        try (FileWriter fw = new FileWriter(ConfigLoader.configFilePath)) {
            fw.write(dumpConfig());
        } catch (IOException e) {
            MsgBox.show("Failed to save file. " + e);
        }
    }

    public static void printCurrentConfig() {
        d.s(dumpConfig());
    }

    private static String dumpConfig() {
        Map<String, Object> rawList = new HashMap<>();
        addSettings(rawList);
        addAlarmConfigs(rawList);

        DumperOptions opt = new DumperOptions();
        opt.setIndent(2);
        opt.setPrettyFlow(true);
        opt.setDefaultFlowStyle(DumperOptions.FlowStyle.BLOCK);

        return new Yaml(opt).dump(rawList);
    }

    private static void addAlarmConfigs(Map<String, Object> map) {
        Map<String, Object> alarmList = new LinkedHashMap<>();
        map.put("alarms", alarmList);

        for (Alarm a : Alarm.getAlarmList()) {
            Map<String, Object> alarmMap = new LinkedHashMap<>();
            alarmList.put(a.name, alarmMap);

            if (a instanceof StaticAlarm) {
                StaticAlarm sa = (StaticAlarm) a;
                alarmMap.put("type", "static");
                alarmMap.put("preSleepStartTime", sa.preSleepStartTime.toString());
                alarmMap.put("sleepStartTime", sa.sleepStartTime.toString());
                alarmMap.put("ringTime", sa.ringTime.toString());
            } else if (a instanceof TimerAlarm) {
                TimerAlarm ta = (TimerAlarm) a;
                alarmMap.put("type", "timer");
                alarmMap.put("startTime", ta.startTime.toString());
                alarmMap.put("preSleepPeriod", ta.preSleepPeriod);
                alarmMap.put("sleepPeriod", ta.sleepPeriod);
            }

            alarmMap.put("enabled", a.enabled);
            alarmMap.put("preSleepEnabled", a.preSleepEnabled);
            alarmMap.put("count", a.count);
        }
    }

    private static void addSettings(Map<String, Object> map) {

    }

}
