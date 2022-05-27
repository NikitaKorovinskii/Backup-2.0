package com.example.mainprog;

import javafx.event.ActionEvent;
import javafx.event.Event;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class acceptCarContController {
    private String ids;
    private Stage stage;
    private Scene scene;
    private Parent root;

    public void accept(ActionEvent event) {
        try {
            root = FXMLLoader.load(getClass().getResource("mainMenu.fxml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
        String title = yesOrno.getText();
        String req;

        DB = new DBConnect();

        try {
            if (this.yesOrno.getText() != "") {
                req = "insert into events ( description, id_car)\n" +
                        "VALUES ( '" + title + "', (select id_Car from trip where trip.id_Trip='" + ids + "'))";
                int in = DB.Insert(req);
            }
            req = "update car set status_issuance = false,status_Booking = false" +
                    " where id_car=(select trip.id_Car from trip\n" +
                    "            where trip.id_Trip='" + ids + "')";
            int re = DB.Update(req);
            req = "delete from tripTimeClient\n" +
                    "where id_Trip='" + ids + "'";
            System.out.println(re);
            int de = DB.Remove(req);
        } catch (SQLException e) {
            e.printStackTrace();
        }

        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();

    }

    public void accept231(ActionEvent event) {
        if (check.isSelected()) {
            yesOrno.setDisable(false);
            yesOrno.setVisible(true);
        } else {
            yesOrno.setText("");
            yesOrno.setVisible(false);
        }
    }

    @FXML
    private Label nameCar;

    @FXML
    private Label Client;
    @FXML
    private Label phone;

    @FXML
    private Label numCar;

    @FXML
    private Label dateNow;
    @FXML
    private CheckBox check;

    @FXML
    private TextArea yesOrno;
    public DBConnect DB;

    @FXML
    void initialize(String id) {
        yesOrno.setText("");
        nameCar.setText("error");
        numCar.setText("error");
        phone.setText("error");
        Client.setText("error");

        ids = id;

        DB = new DBConnect();
        yesOrno.setVisible(false);
        Date currentDate = new Date();
        dateNow.setText(new SimpleDateFormat("dd.MM.yyyy").format(currentDate));

        String req;

        try {
            req = "select Car.name_Car,number_Car,Client.name,middle_Name, Client.number  from trip\n" +
                    "                                 join car on Car.id_Car=trip.id_Car join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                    "                                       join client on trip.id_Client=Client.id_Client\n" +
                    "                    where trip.id_Trip=" + id;
            ResultSet rs = DB.Select(req);
            while (rs.next()) {
                nameCar.setText(rs.getString("name_Car"));
                numCar.setText(rs.getString("number_Car"));
                phone.setText("8" + rs.getString("number"));
                Client.setText((rs.getString("name") + " " + rs.getString("middle_Name")));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }
}