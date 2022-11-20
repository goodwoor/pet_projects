<?php

	$local_path = 'M:/Dev/xamp/htdocs/labs/2';
	$domain_path = '.';
	
	define('_PATH', $domain_path);
	define('_IMG_PATH', $domain_path . '/images');

	require_once _PATH . '/config.php';

	$mode = $_SERVER['REQUEST_METHOD'];
	$smarty -> assign('mode', $mode);

	if ($mode == 'GET') {
		$smarty -> display(_PATH . '/tpls/main.tpl');
	}

	if ($mode == 'POST') {
		// задаём общую структуру и стиль пдф-файла
		$pdf = new FPDF();
		$pdf -> SetTitle('Greeting card');
		$pdf -> setFont('Times', 'B', 20);
		$pdf -> SetTextColor(26, 18, 18);
		$pdf -> AddPage('P');
		$pdf -> SetDisplayMode('real', 'default');
		$pdf -> SetXY (10, 50);
		$pdf -> Write(5, 'Congratulations! :)');
		$pdf -> SetXY (100, 50);

		// сохранение загруженного изображения
		$img_tmp = $_FILES['image']['tmp_name'];
		$img_name = $_FILES['image']['name'];
		$img_path = _IMG_PATH . '/' . $img_name;
		move_uploaded_file($img_tmp, $img_path);
		
		// нанесение текста
		fn_set_text($img_path);

		// нанесение водяного знака
		fn_set_stamp($img_path);

		// вывод итогового изображения в пдф
		$pdf -> Image($img_path, 40, 80, 132, 0);

		// просмотр пдф-файла
		// ob_end_clean();
                $pdf -> Output('result.pdf','I');
	}


function fn_set_stamp($image_path)
{
	$image = imagecreatefrompng($image_path);
	$stamp = imagecreatefrompng(_IMG_PATH . '/' . 'stamp.png' );

	$size_x = imagesx($stamp);
	$size_y = imagesy($stamp);

	// нанесение водяного знака на изображение в правом углу
	imagecopy($image, $stamp, imagesx($image) - $size_x, imagesy($image) - $size_y, 0, 0, imagesx($stamp), imagesy($stamp));

	header('Content-type: image/png');
	imagepng($image, $image_path);
	imagedestroy($image);
}

function fn_set_text($image_path)
{
	$image = imagecreatefrompng($image_path);
	$size_x = imagesx($image);
	$size_y = imagesy($image);

	$text = $_POST['image_text'];
	$color = imageColorAllocate($image, 255, 255, 255);;
	$font = _PATH . '/fonts/tahoma.ttf';
	imagefttext($image, 50, 0, $size_x/2, $size_y/2, $color, $font, $text);

	header('Content-type: image/png');
	imagepng($image, $image_path);
	imagedestroy($image);
}

?>