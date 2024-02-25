<?php
$check = $_POST['ps'];
		$f = fopen("mapArr.txt","r");
		$str = fread($f, filesize("mapArr.txt"));
		fclose($f);
		$mapArr = explode(" ", $str);
		$right = true;
		foreach($check as $key => $value){
			if ($check[$key] != $mapArr[$key]){
				$right = false;
				break;
			}
		}
		if ($right)
			echo "Все верно!!!";
		else
			echo "Судоку решено не правильно!";
?>