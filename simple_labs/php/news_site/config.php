<?php

    set_time_limit (10);
    error_reporting (E_ALL);
    ignore_user_abort (false);

    # SMARTY
	require_once _PATH  . '/libs/smarty/Smarty.class.php';
	$smarty = new Smarty();

	$smarty -> setTemplateDir(_PATH . '/templates/pages');
	$smarty -> setConfigDir(_PATH . '/templates/configs');
	$smarty -> setCompileDir(_PATH . '/templates/compile');
	$smarty -> setCacheDir(_PATH . '/templates/cache');
    