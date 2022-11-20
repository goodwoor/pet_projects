<?php

$local_path = 'M:/Dev/xamp/htdocs/labs/3';
$domain_path = '.';
	
define('_PATH', $domain_path);
define('_TEMPLATES_PATH', $domain_path . '/templates/pages');
define('_IMG_PATH', $domain_path . '/src/images');

require_once _PATH . '/config.php';
require_once _PATH . '/functions.php';

$mode = isset($_POST['mode']) ? $_POST['mode'] : '';

$str_connect = 'mysql:host=fdb29.awardspace.net;dbname=3565379_lab3';
$user = '3565379_lab3';
$password = '12345678quyu';
$db = new PDO($str_connect, $user, $password);
$db -> setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$db -> setAttribute(PDO::ATTR_EMULATE_PREPARES, false);

$query = "SELECT * FROM `news`";
$statement = $db -> prepare($query);
$statement -> execute();
$news = $statement -> fetchAll();
$smarty -> assign('news', $news);

$date_now = date('Y-m-d');
$smarty -> assign('date_now', $date_now);

session_start();

if ($mode === 'Добавить') {
	$heading = isset($_POST['heading']) ? $_POST['heading'] : '';
	$annotation = isset($_POST['annotation']) ? $_POST['annotation'] : '';
	$full_text = isset($_POST['full_text']) ? $_POST['full_text'] : '';
	$hiding = isset($_POST['hiding']) ? '1' : '0';
	$date_publication = date('Y-m-d H:i:s');
	
	$img_path = '';
	if (isset($_FILES['image'])) {
		$img_tmp = $_FILES['image']['tmp_name'];
		$img_name = $_FILES['image']['name'];
		$img_path = _IMG_PATH . '/news/' . $img_name;
		move_uploaded_file($img_tmp, $img_path);
	}

	$query = "INSERT INTO `news` (`heading`, `annotation`, `full_text`, `date_publication`, `image_path`, `hiding`) 
				VALUES (?, ?, ?, ?, ?, ?)";  
	$statement = $db -> prepare($query);
	$statement -> execute([$heading, $annotation, $full_text, $date_publication, $img_path, $hiding]);
}

if ($mode === 'Удалить') {
	$delete_id = isset($_POST['ID_delete']) ? $_POST['ID_delete'] : '';
	$query = "DELETE FROM `news` WHERE ID = :delete_id";
	$statement = $db -> prepare($query);
	$statement -> bindParam('delete_id', $delete_id, PDO::PARAM_INT);
	$statement -> execute();
}

if ($mode === 'Изменить' && isset($_POST['update_ID'])) {
	$query = "SELECT * FROM `news` WHERE ID = :update_id";
	$statement = $db -> prepare($query);
	$statement -> bindParam('update_id', $_POST['update_ID'], PDO::PARAM_INT);
	$statement -> execute();
	$news_values = $statement -> fetch(PDO::FETCH_ASSOC);

	if (!empty($news_values)) {
		$smarty -> assign('news_values', $news_values);
		$_SESSION['update_ID'] = $_POST['update_ID'];
		$_SESSION['update_image_path'] = $news_values['image_path'];
	}
}

if ($mode === 'Сохранить') {
	$update_ID = $_SESSION['update_ID'];
	$update_heading = isset($_POST['update_heading']) ? $_POST['update_heading'] : '';
	$update_annotation = isset($_POST['update_annotation']) ? $_POST['update_annotation'] : '';
	$update_full_text = isset($_POST['update_full_text']) ? $_POST['update_full_text'] : '';
	$update_date = isset($_POST['update_date']) ? $_POST['update_date'] : '';
	$update_hiding = isset($_POST['update_hiding']) ? '1' : '0';

	$update_image_path = '';
	if (isset($_FILES['update_image'])) {
		$old_image = $_SESSION['update_image_path'];
		// unlink($old_image);
		// если в статьях есть одинаковые картинки, то удалятся везде

		$update_img_tmp = $_FILES['update_image']['tmp_name'];
		$update_img_name = $_FILES['update_image']['name'];
		$update_image_path = _IMG_PATH . '/news/' . $update_img_name;
		move_uploaded_file($update_img_tmp, $update_image_path);
	}

	$query = "UPDATE `news` SET heading = ?, annotation = ?, full_text = ?, date_publication = ?, image_path = ?, hiding = ? WHERE id=?";
	$statement = $db -> prepare($query);
	$statement -> execute([$update_heading , $update_annotation, $update_full_text, $update_date, $update_image_path, $update_hiding, $update_ID]);
}

if ($mode == 'Выйти из административного интерфейса') {
	$_SESSION['is_acces_ok'] = false;
	$smarty -> assign('role', 'no_login_admin');
}

if ($mode == 'Главная страница' || $mode == '') {
	$sort_news = $news;
	usort($sort_news, 'compare_news_date');

	foreach($sort_news as $key => $value_news) {
		if ($value_news['hiding'] == '1') {
			unset($sort_news[$key]);
		}
	}

	$smarty -> assign('sort_news', $sort_news);
	$smarty -> assign('role', 'user');
}

if ($mode == 'Читать полностью') {
	$query = "SELECT * FROM `news` WHERE ID = :update_id";
	$statement = $db -> prepare($query);
	$statement -> bindParam('update_id', $_POST['view_ID'], PDO::PARAM_INT);
	$statement -> execute();
	$view_news_values = $statement -> fetch(PDO::FETCH_ASSOC);
	$smarty -> assign('view_news_values', $view_news_values);
	$smarty -> assign('role', 'user_view');
}

if ($mode == 'Администратор') {
	$role = 'no_login_admin';
	if (isset($_SESSION['is_acces_ok']) && ($_SESSION['is_acces_ok'] == true)) {
		$role = 'admin';
	}
	$smarty -> assign('role', $role);
}
if ($mode == 'Вход') {
	$query = "SELECT * FROM `admins`";
	$statement = $db -> prepare($query);
	$statement -> execute();
	$admins = $statement -> fetchAll();

	$login = isset($_POST['username']) ? $_POST['username'] : '';;
	$passw = isset($_POST['passw']) ? $_POST['passw'] : '';
	$is_acces_ok = false;

	foreach ($admins as $index => $admin) {
		$is_login_right = $admin['login'] == $login ? true : false;
		if ($is_login_right) {
			$is_acces_ok = $admin['password'] == $passw ? true : false;
			break;
		}
	}

	if ($is_acces_ok) {
		$smarty -> assign('role', 'admin');
		$smarty -> assign('error_login', '');

		if (isset($_POST['remember']) && ($_POST['remember'] == true)) {
			$_SESSION['is_acces_ok'] = true;
		}
	} else {
		$smarty -> assign('role', 'no_login_admin');
		$smarty -> assign('error_login', 'wrong data for login, try again');
	}
}
	
$is_admin_page = ($mode === 'Добавить') || ($mode === 'Удалить') || ($mode === 'Изменить') || ($mode === 'Сохранить');
if ($is_admin_page) {
	$smarty -> assign('role', 'admin');
}

$smarty -> display(_TEMPLATES_PATH . '/main_page.tpl');
