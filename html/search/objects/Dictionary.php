<?php

class Dictionary
{
    public function showSearch($catname, $string)
    {
        $conn = $this->establishConnection();
        //$selectedCategory = $_POST['category'];
        $sql = $this->selectColumns($catname, $string);

        $result = $conn->query($sql);

        $this->printResult($result);
        $conn->close();
    }

    private function establishConnection(){
        require_once ("/home/phpcredentials/access.php");
        try{
            $conn = new mysqli($servername, $username, $password, $dbname);
            if ($conn->connect_error) {
                die("Connection failed: " . $conn->connect_error);
            }
            return $conn;
        } catch (Exception $e) {
            echo "Something happened: " . $e;
        }
    }

    private function selectColumns($catname, $string) {
        $sql;
        // name, category, keywords, description (table columns)
        if ($catname == 'All') {
            if ($string == "") {
                $sql = "SELECT * FROM dictionary";
            } else {
                $sql = "SELECT * FROM dictionary WHERE name LIKE '" . $string .
                    "%' OR keywords LIKE '" . $string . "%' OR description LIKE '" . $string . "%'";
            }
        } else {
            if ($string == "") {
                $sql = "SELECT * FROM dictionary WHERE category = '" . $catname . "'";
            } else {
                $sql = "SELECT * FROM dictionary WHERE (category = '" . $catname . "') AND (name LIKE '" . $string .
                    "%' OR keywords LIKE '" . $string . "%' OR description LIKE '" . $string . "%')";
            }
        }
        return $sql;
    }

    private function printResult($result) {
        if ($result->num_rows > 0) {
            // output data of each row
            while ($row = $result->fetch_assoc()) {
                $name = $row["name"];
                $name = trim($name);
                $description = $row["description"];
                $keywords = $row["keywords"];
                $category = $row["category"];
                echo '<div class="row">';
                echo '<div class="col-md-2"></div>';

                echo '<div class="col-md-8 panel panel-default">';
                echo '<audio id="' . $name . '" src="http://audemes.aphtech.org/audio/' . strtolower($name) . '.mp3" preload="auto"></audio>';
                echo '<button class="btn btn-primary" type="submit" onclick="document.getElementById(\'' . $name . '\').play();">' . ucfirst(strtolower($name)) . '</button>';
                echo '<p tabindex="0">';
                echo '<strong> Category: </strong>';
                echo $category;
                echo '</p>';
                echo '<p tabindex="0">';
                echo '<strong>Description: </strong>';
                echo $description;
                echo '</p>';
                echo '<p tabindex="0">';
                echo '<strong>Keywords: </strong>';
                echo $keywords;
                echo '</p>';
                echo '</div>';

                echo '<div class="col-md-2"></div>';
                echo '</div>';
            }
        } else {
            echo "0 results";
        }
    }

}