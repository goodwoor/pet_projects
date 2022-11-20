<?php

function smarty_modifier_full_tmp_path($file)
{
	return _TEMPLATES_PATH . '/' . $file;
}	

function smarty_modifier_truncate_img_src($full_path)
{
	//return str_replace('M:/Dev/xamp/htdocs/labs/3/', '', $full_path);
        return $full_path;
}	

function compare_news_date($first_item, $second_item)
{
	$first_date = strtotime($first_item['date_publication']);
	$second_date = strtotime($second_item['date_publication']);
	if ($first_date == $second_date) {
		return 0;
	}
	return ($first_date > $second_date) ? -1 : 1;
}
