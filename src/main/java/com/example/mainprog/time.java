package com.example.mainprog;

import java.util.Date;

public class time {
    public int id;
    public Date time;


    public time(int id, Date time) {
        this.id = id;
        this.time=time;
    }

    public time(){}

    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }

    public Date getTime(){return time;}
    public void setTime(Date time){this.time=time;}


}