package com.example.mainprog;

public class client {
    public int id_Client;
    public String name;
    public String last_Name;
    public String middle_Name;
    public String number_Driver;
    public String phone;


    public client(int id, String name, String last_name, String middle_name, String num_driver,String phone){
        this.id_Client=id;
        this.last_Name=last_name;
        this.name=name;
        this.middle_Name=middle_name;
        this.number_Driver=num_driver;
        this.phone=phone;
    }
    public client(){}

    public int getId() {
        return id_Client;
    }

    public void setId(int id) {
        this.id_Client = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getNumber_Driver() {
        return number_Driver;
    }
    public void setNumber_Driver(String number_Driver) {
        this.number_Driver = number_Driver;
    }

    public void setPhone(String phone){this.phone=phone;}

    public String getPhone(){return phone;}
}
