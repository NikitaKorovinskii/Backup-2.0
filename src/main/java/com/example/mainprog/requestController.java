package com.example.mainprog;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Time;
import java.text.SimpleDateFormat;
import java.time.format.DateTimeParseException;
import java.util.Date;

public class requestController {
    private int idTrip;
    private Stage stage;
    private Scene scene;
    private Parent root;

    public void giveCar(ActionEvent event)  {
        FXMLLoader loader =new FXMLLoader(getClass().getResource("acc.fxml"));
        try {
            root = loader.load();
        } catch (IOException e) {
            e.printStackTrace();
        }
        proccesingConroller scence2 = loader.getController();
        scence2.initialize(String.valueOf(idTrip));

        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }
    public void back(ActionEvent event){
        FXMLLoader loader =new FXMLLoader(getClass().getResource("mainMenu.fxml"));
        try {
            root = loader.load();
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
    private TableView<trip> table;

    @FXML
    private TableColumn id;
    @FXML
    private TableColumn startDate;
    @FXML
    private TableColumn endDate;
    @FXML
    private TableColumn nameCar;

    @FXML
    private TableColumn time;

    public DBConnect DB;
    ObservableList<trip> tripList = FXCollections.observableArrayList();

    @FXML
    void initialize() {
        DB = new DBConnect();
        Date currentDate = new Date();
        table.setOnMouseClicked(mouseEvent -> {
            TableView.TableViewSelectionModel<trip> temp = table.getSelectionModel();
            idTrip=temp.getSelectedItem().getId();
            System.out.println(idTrip);
        });


         dateNow.setText(new SimpleDateFormat("dd.MM.yyyy").format(currentDate));
         Date x = currentDate;

        id.setCellValueFactory(new PropertyValueFactory<trip, Integer>("id"));
        startDate.setCellValueFactory(new PropertyValueFactory<trip, Date>("startDate"));
        endDate.setCellValueFactory(new PropertyValueFactory<trip, Date>("endDate"));
        time.setCellValueFactory(new PropertyValueFactory<trip, Time>("time"));
        nameCar.setCellValueFactory(new PropertyValueFactory<trip,String >("nameCar"));
        String req;

        try {
            req = "select trip.id_Trip, start_Date,end_Date,Car.name_Car,number_Car, tripTimeClient.time  from trip\n" +
                    "                    join car on Car.id_Car=trip.id_Car\n" +
                    "                    join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                    "where status_Booking=true and status_Issuance=false and start_Date= '"+x+"'order by trip.id_Trip";
            ResultSet rs = DB.Select(req);
            while (rs.next()){
                tripList.add(new trip (rs.getInt("id_Trip"),
                        rs.getDate("start_Date"),
                        rs.getDate("end_Date"),
                        rs.getString("name_Car"),
                        rs.getTime("time"),
                        rs.getString("number_Car")
                ));
            }
            table.setItems(tripList);
        } catch (SQLException e) {
            e.printStackTrace();
        }



    }
}
