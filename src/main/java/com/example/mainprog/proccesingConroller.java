package com.example.mainprog;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class proccesingConroller {
    private String ids;
    private Stage stage;
    private Scene scene;
    private Parent root;
    public DBConnect DB;


    public void giveCar(ActionEvent event) {
        try {
            root = FXMLLoader.load(getClass().getResource("mainMenu.fxml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
        DB = new DBConnect();
        String req;

        try {
            req = "update car set status_issuance = true where id_car=(select trip.id_Car from trip\n" +
                    "                                                                       where trip.id_Trip='"+ids+"')";
            int re = DB.Update(req);
            System.out.println(re);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @FXML
    private Label endDate;

    @FXML
    private Label Client;

    @FXML
    private Label nameCar;

    @FXML
    private Label numCar;

    @FXML
    private Label num_driver;
    @FXML
    private Label phone;


    @FXML
    private Label dateNow;



    @FXML
    void initialize(String id) {
        DB = new DBConnect();
        ids = id;
        endDate.setText("error");
        num_driver.setText("error");
        nameCar.setText("error");
        numCar.setText("error");
        phone.setText("error");
        Client.setText("error");

        dateNow.setText(new SimpleDateFormat("dd.MM.yyyy").format(new Date()));

        String req;

        try {
            req = "select end_Date, Car.name_Car,number_Car, c.middle_Name, c.name, c.number,c.number_driver from trip\n" +
                    "                                                        join car on Car.id_Car=trip.id_Car\n" +
                    "                                                        join client c on trip.id_Client = c.id_client\n" +
                    "                                                      where trip.id_Trip=" + id;
            ResultSet rs = DB.Select(req);
            while (rs.next()) {
                endDate.setText(rs.getString("end_Date"));
                num_driver.setText(rs.getString("number_Driver"));
                nameCar.setText(rs.getString("name_Car"));
                numCar.setText(rs.getString("number_Car"));
                phone.setText("8" + rs.getString("number"));
                Client.setText(( rs.getString("name") + " " + rs.getString("middle_Name")));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
