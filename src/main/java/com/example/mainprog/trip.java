package com.example.mainprog;

import java.sql.Time;
import java.util.Date;

public class trip {
    public int idTrip;
    public Date startDate;
    public Date endDate;
    public String nameCar;
    public String numCar;
    public Date time;

    public trip(int idTrip, Date startDate, Date endDate,String nameCar,Date time,String numCar) {
        this.idTrip = idTrip;
        this.startDate = startDate;
        this.endDate=endDate;
        this.nameCar=nameCar;
        this.numCar=numCar;
        this.time=time;

    }

    public trip() {
    }

    public int getId() {
        return idTrip;
    }
    public void setId(int idTrip) {
        this.idTrip = idTrip;
    }


    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }
    public Date getStartDate() {
        return startDate;
    }


    public void setEndDate(Date endDate) {
        this.endDate = endDate;
    }
    public Date getEndDate() {
        return endDate;
    }


    public Date getTime(){return time;}
    public void setTime(Date time){this.time=time;}

    public void setNameCar(String nameCar) {
        this.nameCar = nameCar;
    }

    public String getNameCar() {
        return nameCar;
    }

    public void setNumCar(String numCar) {
        this.nameCar = numCar;
    }

    public String getNumCar() {
        return numCar;
    }


}
