<?php

    set_time_limit (10);
    error_reporting (E_ALL);
    ignore_user_abort (false);
	
	#FPDF
	require_once _PATH . '/libs/fpdf/fpdf.php';

        # SMARTY
	require_once _PATH . '/libs/smarty/Smarty.class.php';
	$smarty = new Smarty();

	$smarty -> setTemplateDir(_PATH. '/tpls');
	$smarty -> setConfigDir(_PATH . '/tpls/configs');
	$smarty -> setCompileDir(_PATH . '/tpls/compile');
	$smarty -> setCacheDir(_PATH. '/tpls/cache');
    