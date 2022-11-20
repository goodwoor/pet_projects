<?php	

	print('<h2> Ссылки взяты с адреса "http://spacemorgue.com/crossroads/".</h2>');

	print('Ссылки первого уровня выделены жирным шрифтом, для каждой из них приведены ссылки второго уровня (пронумерованы). <br> <br>');

	$page = file_get_contents('http://spacemorgue.com/crossroads/');
	$doc = new DOMDocument();
	@$doc -> loadHTML($page);
	$elements = $doc -> getElementsByTagName("a");

	$internal_links = [];
	foreach ($elements as $el) {
		$link = $el -> getAttribute("href");
		if (strpos($link, 'spacemorgue.com') == true) {
		    
                        // меняем протокол на http, сервер spacemorgue почему-то не позволяет работать с https
			$link = str_replace('https', 'http', $link);
			
			// сохранение ссылки в ключе обеспечит уникальность ссылок первого уровня
			$internal_links[$link] = [];

			// ищем ссылки второго уровня
			$page_second_level = false;

			try {
			    
				@$page_second_level = file_get_contents($link);
				if ($page_second_level == false) {
					continue;
				}
			}
			catch (Exception $e) {
				continue;
			}

			$doc_second_level = new DOMDocument();
			@$doc_second_level -> loadHTML($page_second_level);
			$elements_second_level = $doc_second_level -> getElementsByTagName("a");

			foreach ($elements_second_level as $el_2_lvl) {
				$link_2_lvl = $el_2_lvl -> getAttribute("href");

				$is_internal_link = strpos($link_2_lvl, 'spacemorgue.com') == true;
				$is_unic_url = array_search($link_2_lvl, $internal_links[$link]) == false;

				if ($is_internal_link && $is_unic_url) {
					$internal_links[$link][] = $link_2_lvl;
				}
			}

		}
	}

	foreach ($internal_links as $key => $links_second_level) {

		if (empty($internal_links[$key])) {
			print('<b>' . $key . ';' . '</b>');
			print('<br> <br>');
			continue;
		}

		print('<b>' . $key . ':' . '</b>');
		print('<br>');

		foreach($links_second_level as $key_2_lvl => $link_2_lvl)
		{	
			print('  ' . (string)($key_2_lvl + 1) . '. ' . $link_2_lvl . ';');
			print('<br>');
		}

		print('<br> <br>');
	}