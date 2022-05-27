package com.example.mainprog;

import java.sql.*;

public class DBConnect {

    private static Connection connection = null;

    public DBConnect(){
        try {
            String DateBaseURL = "jdbc:postgresql://45.10.244.15:55532/work100013";
            String User = "work100013";
            String Password = "CiDGtd6n9RC2oZquzHgL";
            connection = DriverManager.getConnection(DateBaseURL, User, Password);
        } catch (SQLException exception) {
            exception.printStackTrace();
        }
    }

    public ResultSet Select(String request) throws SQLException {
        Statement statement = connection.createStatement();
        String requestUpd = request;
        ResultSet rs = statement.executeQuery(requestUpd);
        return rs;
    }
    public int Insert(String request) throws SQLException {
        Statement statement = connection.createStatement();
        String requestUpd = request;
        int result = statement.executeUpdate(requestUpd);
        return result;
    }

    public int Update(String request) throws SQLException {
        Statement statement = connection.createStatement();
        String requestUpd = request;
        int result = statement.executeUpdate(requestUpd);
        return result;
    }
    public int Remove(String request) throws SQLException {
        Statement statement = connection.createStatement();
        String requestUpd = request;
        int result = statement.executeUpdate(requestUpd);
        return result;
    }

}
