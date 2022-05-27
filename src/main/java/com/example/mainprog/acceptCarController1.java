package com.example.mainprog;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Modality;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Time;
import java.text.SimpleDateFormat;
import java.util.Date;

public class acceptCarController1 {
    private int idTrip;
    private Stage stage;
    private Scene scene;
    private Parent root;

    public void acceptCar(ActionEvent event) {

        FXMLLoader loader = new FXMLLoader(getClass().getResource("acceptCarCont.fxml"));
        try {
            root = loader.load();
        } catch (IOException e) {
            e.printStackTrace();
        }
        acceptCarContController scence2 = loader.getController();
        scence2.initialize(String.valueOf(idTrip));

        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();

    }

    public void back(ActionEvent event) {
        FXMLLoader loader = new FXMLLoader(getClass().getResource("mainMenu.fxml"));
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
    private TableView<trip> table;

    @FXML
    private Label dateNow;

    @FXML
    private TextField numCar1;

    @FXML
    private ComboBox numNameCar;

    @FXML
    private TableColumn endDate;

    @FXML
    private TableColumn id;

    @FXML
    private TableColumn nameCar;

    @FXML
    private TableColumn numCar;

    @FXML
    private TableColumn startDate;


    public DBConnect DB;
    ObservableList<trip> tripList = FXCollections.observableArrayList();


    @FXML
    void initialize() {
        numCar1.setText("");
        numNameCar.getItems().addAll("Все");
        DB = new DBConnect();
        Date currentDate = new Date();
        dateNow.setText(new SimpleDateFormat("dd.MM.yyyy").format(currentDate));
        table.setOnMouseClicked(mouseEvent -> {
            TableView.TableViewSelectionModel<trip> temp = table.getSelectionModel();
            idTrip = temp.getSelectedItem().getId();
            System.out.println(idTrip);
        });

        dateNow.setText(new SimpleDateFormat("dd.MM.yyyy").format(currentDate));

        id.setCellValueFactory(new PropertyValueFactory<trip, Integer>("id"));
        startDate.setCellValueFactory(new PropertyValueFactory<trip, Date>("startDate"));
        endDate.setCellValueFactory(new PropertyValueFactory<trip, Date>("endDate"));
        nameCar.setCellValueFactory(new PropertyValueFactory<trip, String>("nameCar"));
        numCar.setCellValueFactory(new PropertyValueFactory<trip, Time>("numCar"));
        String req;

        try {
            req = "select trip.id_Trip,time, start_Date,end_Date,Car.name_Car,number_Car from trip\n" +
                    "                                      join car on Car.id_Car=trip.id_Car\n" +
                    "                                       join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                    "                    where status_Booking=true and status_Issuance=true order by trip.id_Trip";
            ResultSet rs = DB.Select(req);
            while (rs.next()) {
                tripList.add(new trip(
                        rs.getInt("id_Trip"),
                        rs.getDate("start_Date"),
                        rs.getDate("end_Date"),
                        rs.getString("name_Car"),
                        rs.getTime("time"),
                        rs.getString("number_Car")

                ));

            }

            table.setItems(tripList);

            try {
                req = "select Car.name_Car  from trip " +
                        "join car on Car.id_Car=trip.id_Car\n" +
                        "                                       join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                        "                    where status_Booking=true and status_Issuance=true";
                ResultSet rsz = DB.Select(req);
                while (rsz.next()) {
                    nameCar.setText(rsz.getString("name_Car"));
                    numNameCar.getItems().addAll(nameCar.getText());
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void search(ActionEvent actionEvent) {
        tripList.clear();
        String req;
        String number = numCar1.getText().toUpperCase();
        if (numCar1.getText()=="") {
            if (numNameCar.getValue() == "Все") {
                try {
                    req = "select trip.id_Trip,time, start_Date,end_Date,Car.name_Car,number_Car from trip\n" +
                            "                                      join car on Car.id_Car=trip.id_Car\n" +
                            "                                       join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                            "                    where status_Booking=true and status_Issuance=true order by trip.id_Trip";
                    ResultSet rs = DB.Select(req);
                    while (rs.next()) {
                        tripList.add(new trip(
                                rs.getInt("id_Trip"),
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

            } else {
                try {
                    req = "select trip.id_Trip,time, start_Date,end_Date,Car.name_Car,number_Car from trip\n" +
                            "                                      join car on Car.id_Car=trip.id_Car\n" +
                            "                                       join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                            "                    where status_Booking=true and status_Issuance=true and name_Car='" + numNameCar.getValue() + "'";
                    ResultSet rs = DB.Select(req);
                    while (rs.next()) {
                        tripList.add(new trip(
                                rs.getInt("id_Trip"),
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
        else {
            if (numNameCar.getValue() == "Все") {
            try {
                req = "select trip.id_Trip,time, start_Date,end_Date,Car.name_Car,number_Car from trip\n" +
                        "                                      join car on Car.id_Car=trip.id_Car\n" +
                        "                                       join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                        "                    where status_Booking=true and status_Issuance=true and number_car='"+number+"' order by trip.id_Trip";
                ResultSet rs = DB.Select(req);
                while (rs.next()) {
                    tripList.add(new trip(
                            rs.getInt("id_Trip"),
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

        } else {
            try {
                req = "select trip.id_Trip,time, start_Date,end_Date,Car.name_Car,number_Car from trip\n" +
                        "                                      join car on Car.id_Car=trip.id_Car\n" +
                        "                                       join tripTimeClient on trip.id_Trip = tripTimeClient.id_trip\n" +
                        "                    where status_Booking=true and status_Issuance=true and name_Car='" + numNameCar.getValue() + "'and number_car='"+number+"'";
                ResultSet rs = DB.Select(req);
                while (rs.next()) {
                    tripList.add(new trip(
                            rs.getInt("id_Trip"),
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

    }
}
