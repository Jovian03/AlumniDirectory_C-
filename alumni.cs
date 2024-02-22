import java.util.Scanner;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class AlumniManagementSystem {
    static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        int choice;
        do {
            System.out.println("Welcome to The Public School Alumni Association");
            System.out.println("1. New member");
            System.out.println("2. Existing member");
            System.out.println("3. Administration");
            System.out.println("Enter your choice: ");
            choice = scanner.nextInt();
            switch (choice) {
                case 1:
                    newRegistration();
                    break;
                case 2:
                    login();
                    break;
                case 3:
                    adminMenu();
                    break;
                default:
                    System.out.println("Invalid choice!");
            }
        } while (choice != 3);
    }

    public static void newRegistration() {
        System.out.println("New Registration");
        // Accepting details
        System.out.print("Enter admission number: ");
        int admissionNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.print("Enter name: ");
        String name = scanner.nextLine();
        System.out.print("Enter email id: ");
        String email = scanner.nextLine();
        System.out.print("Enter mobile number: ");
        String mobileNumber = scanner.nextLine();
        System.out.print("Enter present educational status: ");
        String educationalStatus = scanner.nextLine();
        System.out.print("Enter year of passing out: ");
        int yearOfPassingOut = scanner.nextInt();
        scanner.nextLine();
        System.out.print("Set password: ");
        String password = scanner.nextLine();

        // Writing details to file
        try {
            FileWriter alumniFileWriter = new FileWriter("alumni.txt", true);
            FileWriter passwordFileWriter = new FileWriter("password.txt", true);
            alumniFileWriter.write(admissionNumber + "," + name + "," + email + "," + mobileNumber + "," + educationalStatus + "," + yearOfPassingOut + "\n");
            passwordFileWriter.write(admissionNumber + "," + password + "\n");
            alumniFileWriter.close();
            passwordFileWriter.close();
            System.out.println("Successfully registered!");
        } catch (IOException e) {
            System.out.println("An error occurred while registering.");
            e.printStackTrace();
        }
    }

    public static void login() {
        System.out.println("Login");
        System.out.print("Enter admission number: ");
        int admissionNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.print("Enter password: ");
        String password = scanner.nextLine();

        // Checking login credentials
        try {
            File alumniFile = new File("alumni.txt");
            File passwordFile = new File("password.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            Scanner passwordScanner = new Scanner(passwordFile);
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String alumniData = alumniScanner.nextLine();
                String[] alumniDetails = alumniData.split(",");
                if (Integer.parseInt(alumniDetails[0]) == admissionNumber) {
                    while (passwordScanner.hasNextLine()) {
                        String passwordData = passwordScanner.nextLine();
                        String[] passwordDetails = passwordData.split(",");
                        if (Integer.parseInt(passwordDetails[0]) == admissionNumber && passwordDetails[1].equals(password)) {
                            found = true;
                            break;
                        }
                    }
                    break;
                }
            }
            alumniScanner.close();
            passwordScanner.close();
            if (found) {
                System.out.println("Login successful!");
                // Proceed with main menu
                mainMenu();
            } else {
                System.out.println("Incorrect admission number or password!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while logging in.");
            e.printStackTrace();
        }
    }

    public static void mainMenu() {
        int choice;
        do {
            System.out.println("Main Menu");
            System.out.println("1. Notifications");
            System.out.println("2. Search");
            System.out.println("3. Reports");
            System.out.println("4. Maintenance");
            System.out.println("5. Exit");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            switch (choice) {
                case 1:
                    displayNotifications();
                    break;
                case 2:
                    search();
                    break;
                case 3:
                    displayReports();
                    break;
                case 4:
                    maintenance();
                    break;
                case 5:
                    System.out.println("Exiting...");
                    break;
                default:
                    System.out.println("Invalid choice!");
            }
        } while (choice != 5);
    }

    public static void displayNotifications() {
        System.out.println("Notifications");
        System.out.println("1. Reunion of 2011-12 batch on September 12, 2019 at school.");
        System.out.println("2. Seminar for class X students on Cyber Security will be conducted on 12-7-2019 by alumni.");
        System.out.print("Press any key to continue: ");
        scanner.nextLine();
    }

    public static void search() {
        int choice;
        do {
            System.out.println("Search");
            System.out.println("1. Search by admission number");
            System.out.println("2. Search by name");
            System.out.println("3. Back to main menu");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            switch (choice) {
                case 1:
                    searchByAdmissionNumber();
                    break;
                case 2:
                    searchByName();
                    break;
                case 3:
                    break;
                default:
                    System.out.println("Invalid choice!");
            }
        } while (choice != 3);
    }

    public static void searchByAdmissionNumber() {
        System.out.println("Search by Admission Number");
        System.out.print("Enter the admission number to be searched: ");
        int admissionNumber = scanner.nextInt();
        try {
            File alumniFile = new File("alumni.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String alumniData = alumniScanner.nextLine();
                String[] alumniDetails = alumniData.split(",");
                if (Integer.parseInt(alumniDetails[0]) == admissionNumber) {
                    found = true;
                    System.out.println("Name: " + alumniDetails[1]);
                    System.out.println("Admission Number: " + alumniDetails[0]);
                    System.out.println("Email: " + alumniDetails[2]);
                    System.out.println("Mobile Number: " + alumniDetails[3]);
                    System.out.println("Educational Status: " + alumniDetails[4]);
                    System.out.println("Year of Passing Out: " + alumniDetails[5]);
                    break;
                }
            }
            alumniScanner.close();
            if (!found) {
                System.out.println("Record not found!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while searching.");
            e.printStackTrace();
        }
    }

    public static void searchByName() {
        System.out.println("Search by Name");
        System.out.print("Enter the name to be searched: ");
        scanner.nextLine();
        String name = scanner.nextLine();
        try {
            File alumniFile = new File("alumni.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String alumniData = alumniScanner.nextLine();
                String[] alumniDetails = alumniData.split(",");
                if (alumniDetails[1].equalsIgnoreCase(name)) {
                    found = true;
                    System.out.println("Name: " + alumniDetails[1]);
                    System.out.println("Admission Number: " + alumniDetails[0]);
                    System.out.println("Email: " + alumniDetails[2]);
                    System.out.println("Mobile Number: " + alumniDetails[3]);
                    System.out.println("Educational Status: " + alumniDetails[4]);
                    System.out.println("Year of Passing Out: " + alumniDetails[5]);
                    break;
                }
            }
            alumniScanner.close();
            if (!found) {
                System.out.println("Record not found!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while searching.");
            e.printStackTrace();
        }
    }

    public static void displayReports() {
        int choice;
        do {
            System.out.println("Reports");
            System.out.println("1. Display all details");
            System.out.println("2. Display alumni of a particular year");
            System.out.println("3. Display alumni based on qualification");
            System.out.println("4. Back to main menu");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            switch (choice) {
                case 1:
                    displayAllDetails();
                    break;
                case 2:
                    displayAlumniByYear();
                    break;
                case 3:
                    displayAlumniByQualification();
                    break;
                case 4:
                    break;
                default:
                    System.out.println("Invalid choice!");
            }
        } while (choice != 4);
    }

    public static void displayAllDetails() {
        System.out.println("All Members");
        try {
            File alumniFile = new File("alumni.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            while (alumniScanner.hasNextLine()) {
                String alumniData = alumniScanner.nextLine();
                String[] alumniDetails = alumniData.split(",");
                System.out.println("Name: " + alumniDetails[1]);
                System.out.println("Admission Number: " + alumniDetails[0]);
                System.out.println("Email: " + alumniDetails[2]);
                System.out.println("Mobile Number: " + alumniDetails[3]);
                System.out.println("Educational Status: " + alumniDetails[4]);
                System.out.println("Year of Passing Out: " + alumniDetails[5]);
                System.out.println();
            }
            alumniScanner.close();
        } catch (IOException e) {
            System.out.println("An error occurred while displaying details.");
            e.printStackTrace();
        }
    }

    public static void displayAlumniByYear() {
        System.out.println("Display Alumni by Year");
        System.out.print("Enter the year of passing out: ");
        int year = scanner.nextInt();
        try {
            File alumniFile = new File("alumni.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String alumniData = alumniScanner.nextLine();
                String[] alumniDetails = alumniData.split(",");
                if (Integer.parseInt(alumniDetails[5]) == year) {
                    found = true;
                    System.out.println("Name: " + alumniDetails[1]);
                    System.out.println("Admission Number: " + alumniDetails[0]);
                    System.out.println("Email: " + alumniDetails[2]);
                    System.out.println("Mobile Number: " + alumniDetails[3]);
                    System.out.println("Educational Status: " + alumniDetails[4]);
                    System.out.println("Year of Passing Out: " + alumniDetails[5]);
                    System.out.println();
                }
            }
            alumniScanner.close();
            if (!found) {
                System.out.println("Record not found!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while displaying details.");
            e.printStackTrace();
        }
    }

    public static void displayAlumniByQualification() {
        System.out.println("Display Alumni by Qualification");
        System.out.print("Enter the educational qualification: ");
        scanner.nextLine();
        String qualification = scanner.nextLine();
        try {
            File alumniFile = new File("alumni.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String alumniData = alumniScanner.nextLine();
                String[] alumniDetails = alumniData.split(",");
                if (alumniDetails[4].equalsIgnoreCase(qualification)) {
                    found = true;
                    System.out.println("Name: " + alumniDetails[1]);
                    System.out.println("Admission Number: " + alumniDetails[0]);
                    System.out.println("Email: " + alumniDetails[2]);
                    System.out.println("Mobile Number: " + alumniDetails[3]);
                    System.out.println("Educational Status: " + alumniDetails[4]);
                    System.out.println("Year of Passing Out: " + alumniDetails[5]);
                    System.out.println();
                }
            }
            alumniScanner.close();
            if (!found) {
                System.out.println("Record not found!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while displaying details.");
            e.printStackTrace();
        }
    }

    public static void maintenance() {
        int choice;
        do {
            System.out.println("Maintenance");
            System.out.println("1. Modify");
            System.out.println("2. Delete");
            System.out.println("3. Back to main menu");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            switch (choice) {
                case 1:
                    modify();
                    break;
                case 2:
                    delete();
                    break;
                case 3:
                    break;
                default:
                    System.out.println("Invalid choice!");
            }
        } while (choice != 3);
    }

    public static void modify() {
        System.out.println("Modify");
        System.out.print("Enter the admission number to be modified: ");
        int admissionNumber = scanner.nextInt();
        scanner.nextLine();
        try {
            File alumniFile = new File("alumni.txt");
            File passwordFile = new File("password.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            Scanner passwordScanner = new Scanner(passwordFile);
            StringBuilder alumniData = new StringBuilder();
            StringBuilder passwordData = new StringBuilder();
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String currentAlumniData = alumniScanner.nextLine();
                String[] alumniDetails = currentAlumniData.split(",");
                if (Integer.parseInt(alumniDetails[0]) == admissionNumber) {
                    found = true;
                    System.out.println("Current Details:");
                    System.out.println("Name: " + alumniDetails[1]);
                    System.out.println("Admission Number: " + alumniDetails[0]);
                    System.out.println("Email: " + alumniDetails[2]);
                    System.out.println("Mobile Number: " + alumniDetails[3]);
                    System.out.println("Educational Status: " + alumniDetails[4]);
                    System.out.println("Year of Passing Out: " + alumniDetails[5]);
                    System.out.println();
                    System.out.println("Enter new details (Press Enter to retain old details):");
                    System.out.print("Name: ");
                    String name = scanner.nextLine();
                    System.out.print("Email: ");
                    String email = scanner.nextLine();
                    System.out.print("Mobile Number: ");
                    String mobileNumber = scanner.nextLine();
                    System.out.print("Educational Status: ");
                    String educationalStatus = scanner.nextLine();
                    System.out.print("Year of Passing Out: ");
                    int yearOfPassingOut = scanner.nextInt();
                    scanner.nextLine();
                    while (passwordScanner.hasNextLine()) {
                        String currentPasswordData = passwordScanner.nextLine();
                        String[] passwordDetails = currentPasswordData.split(",");
                        if (Integer.parseInt(passwordDetails[0]) == admissionNumber) {
                            passwordData.append(passwordDetails[0]).append(",").append(passwordDetails[1]).append("\n");
                        }
                    }
                    if (!name.isEmpty()) {
                        alumniData.append(admissionNumber).append(",").append(name).append(",").append(email).append(",").append(mobileNumber).append(",").append(educationalStatus).append(",").append(yearOfPassingOut).append("\n");
                    } else {
                        alumniData.append(currentAlumniData).append("\n");
                    }
                } else {
                    alumniData.append(currentAlumniData).append("\n");
                }
            }
            alumniScanner.close();
            passwordScanner.close();
            if (!found) {
                System.out.println("Record not found!");
            } else {
                FileWriter alumniFileWriter = new FileWriter("alumni.txt");
                FileWriter passwordFileWriter = new FileWriter("password.txt");
                alumniFileWriter.write(alumniData.toString());
                passwordFileWriter.write(passwordData.toString());
                alumniFileWriter.close();
                passwordFileWriter.close();
                System.out.println("Record modified successfully!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while modifying the record.");
            e.printStackTrace();
        }
    }

    public static void delete() {
        System.out.println("Delete");
        System.out.print("Enter the admission number to be deleted: ");
        int admissionNumber = scanner.nextInt();
        scanner.nextLine();
        try {
            File alumniFile = new File("alumni.txt");
            File passwordFile = new File("password.txt");
            Scanner alumniScanner = new Scanner(alumniFile);
            Scanner passwordScanner = new Scanner(passwordFile);
            StringBuilder alumniData = new StringBuilder();
            StringBuilder passwordData = new StringBuilder();
            boolean found = false;
            while (alumniScanner.hasNextLine()) {
                String currentAlumniData = alumniScanner.nextLine();
                String[] alumniDetails = currentAlumniData.split(",");
                if (Integer.parseInt(alumniDetails[0]) == admissionNumber) {
                    found = true;
                    System.out.println("Deleted Details:");
                    System.out.println("Name: " + alumniDetails[1]);
                    System.out.println("Admission Number: " + alumniDetails[0]);
                    System.out.println("Email: " + alumniDetails[2]);
                    System.out.println("Mobile Number: " + alumniDetails[3]);
                    System.out.println("Educational Status: " + alumniDetails[4]);
                    System.out.println("Year of Passing Out: " + alumniDetails[5]);
                    System.out.println();
                } else {
                    alumniData.append(currentAlumniData).append("\n");
                }
            }
            while (passwordScanner.hasNextLine()) {
                String currentPasswordData = passwordScanner.nextLine();
                String[] passwordDetails = currentPasswordData.split(",");
                if (Integer.parseInt(passwordDetails[0]) != admissionNumber) {
                    passwordData.append(currentPasswordData).append("\n");
                }
            }
            alumniScanner.close();
            passwordScanner.close();
            if (!found) {
                System.out.println("Record not found!");
            } else {
                FileWriter alumniFileWriter = new FileWriter("alumni.txt");
                FileWriter passwordFileWriter = new FileWriter("password.txt");
                alumniFileWriter.write(alumniData.toString());
                passwordFileWriter.write(passwordData.toString());
                alumniFileWriter.close();
                passwordFileWriter.close();
                System.out.println("Record deleted successfully!");
            }
        } catch (IOException e) {
            System.out.println("An error occurred while deleting the record.");
            e.printStackTrace();
        }
    }

    public static void adminMenu() {
        int choice;
        do {
            System.out.println("Admin Menu");
            System.out.println("1. Notifications");
            System.out.println("2. Search");
            System.out.println("3. Reports");
            System.out.println("4. Maintenance");
            System.out.println("5. Exit");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            switch (choice) {
                case 1:
                    displayNotifications();
                    break;
                case 2:
                    search();
                    break;
                case 3:
                    displayReports();
                    break;
                case 4:
                    maintenance();
                    break;
                case 5:
                    System.out.println("Exiting...");
                    break;
                default:
                    System.out.println("Invalid choice!");
            }
        } while (choice != 5);
    }
}
