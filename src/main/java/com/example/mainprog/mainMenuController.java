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
import java.text.SimpleDateFormat;
import java.util.Date;

public class mainMenuController {
    private Stage stage;
    private Scene scene;
    private Parent root;

    public void acceptCar(ActionEvent event)  {
        try {
            root = FXMLLoader.load(getClass().getResource("acceptCarNew.fxml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }
    public void giveCar(ActionEvent event)  {
        try {
            root = FXMLLoader.load(getClass().getResource("request.fxml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }
    @FXML
    private Label dateNow;
    @FXML
    void initialize() {

        Date currentDate = new Date();
        dateNow.setText(new SimpleDateFormat("dd.MM.yyyy").format(currentDate));
    }
}




