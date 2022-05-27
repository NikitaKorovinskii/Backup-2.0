package com.example.mainprog;

import javafx.scene.text.Text;

public class event {
        public int id;
        public String tittle;

        public event( int id , String tittle){
            this.id=id;
            this.tittle=tittle;
        }
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setNameCar(String tittle) {
        this.tittle = tittle;
    }

    public String getNameCar() {
        return tittle;
    }
}
