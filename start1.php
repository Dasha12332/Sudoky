<?php
// Данные для MySQL сервера
$DBHost = "localhost"; // Хост
$DBUser = "root"; // Имя пользователя
$DBPassword = ""; // Пароль
$DBName = "game"; // Имя базы данных
// Подключаемся к MySQL серверу
$Link = mysqli_connect($DBHost, $DBUser, $DBPassword);
// Выбираем нашу базу данных
mysqli_select_db($Link, $DBName);

	//echo('<form action="" method=GET>');
	$pass = array();
	while ( count ($pass) != $_POST['level']){
		$r = rand(0, 80);
		$add = true;
		for ($i=0; $i< count($pass); $i++){
			if ($r == $pass[$i]){
				$add = false;
				break;
			}
		}
		if ($add)
			$pass[] = $r;
	}
	$mapN = rand(1, 10);
	$Query = "SELECT pole AS _msg FROM sudoku WHERE id = $mapN";
	$result = mysqli_query($Link, $Query);
	$map = mysqli_fetch_assoc($result);
	$mapArr = explode(" ", $map['_msg']);
	$f = fopen("mapArr.txt","w");
	fwrite($f, $map['_msg']);
	fclose($f);
	//echo(" <table border=1 align=center width=450 height=450>");
	$n = 0;
	for($i=0;$i<9; $i++){
		//echo("<tr>");
		for($j=0;$j<9; $j++){
			$add = true;
			for ($k=0; $k< count($pass); $k++){
				if ( $n == $pass[$k]){
					$add = false;
					break;
				}
			}
			if ($add)
				echo("$mapArr[$n] ");
			else
				echo(" ");
			$n ++;		
		}
		//echo("</tr>");
	}
	//echo("</table>");
	//echo('<input type = "submit" value="Проверить">');	
?># Курсова
