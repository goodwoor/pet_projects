<div> 
   <b> Просмотр новостей: </b>

    <table border="1">
        <tr> 
            <td>Идентификатор</td>
            <td>Заголовок</td>
            <td>Краткая аннотация </td>
            <td>Текст статьи</td>
            <td>Дата публикации</td>
            <td>Изображение статьи (путь до него):</td>
            <td>Скрытая статья</td>
        </tr>

        {foreach from=$news item=news_item}
            <tr>
                <td> {$news_item.ID} </td>
                <td> {$news_item.heading} </td>
                <td> {$news_item.annotation} </td>
                <td> {$news_item.full_text} </td>
                <td> {$news_item.date_publication} </td>
                <td> {$news_item.image_path|truncate_img_src} </td>
                <td> {$news_item.hiding} </td>
            </tr>
        {/foreach}
        <br> <br>
    </table>

    <p> <b> Добавление новой статьи: </b> </p>
    <form enctype="multipart/form-data" method="post" action="index.php"> 
        Заголовок: <input type="text" name="heading"><br><br> 
        Краткая аннотация: <input type="text" name="annotation"><br><br> 
        Текст статьи: <br> <textarea name="full_text" rows="15" cols="55"></textarea><br><br>
        Изображение статьи (в формате png): <input type="file" name="image"/><br><br>
        Скрытая статья: <input type="checkbox" name="hiding"><br><br> 
        <input type="submit" name="mode" value="Добавить"><br><br><br> 
    </form>

    <p> <b> Удаление статьи: </b> </p>
    <form method="post" action="index.php"> 
        Идентификатор статьи: <input type="text" name="ID_delete"><br><br> 
        <input type="submit" name="mode" value="Удалить"><br><br><br> 
    </form>

    <p> <b> Редактирование статьи: </b> </p>
    <form method="post" action="index.php"> 
        Идентификатор статьи: <input type="text" name="update_ID"><br><br>
        <input type="submit" name="mode" value="Изменить"><br><br><br> 
    </form>

    <form enctype="multipart/form-data" method="post" action="index.php"> 
        <table border="1">
        <tr> 
            <td>Атрибут</td>
            <td>Старое значение</td>
            <td>Новое значение(введите)</td>
        </tr>

        <tr> 
            <td>Заголовок</td>
            {if isset($update_news_values.heading)}
                <td> {$update_news_values.heading} </td>
                <td><input type="text" name="update_heading" value="{$update_news_values.heading}"></td>
            {/if}
        </tr>

        <tr> 
            <td>Краткая аннотация </td>
            {if isset($update_news_values.annotation)}
                <td> {$update_news_values.annotation} </td>
                <td><input type="text" name="update_annotation" value="{$update_news_values.annotation}"></td>
            {/if}
        </tr>

        <tr> 
            <td>Текст статьи</td>
            {if isset($update_news_values.full_text)}
                <td> {$update_news_values.full_text} </td>
                <td><textarea name="update_full_text" rows="15" cols="55" value="{$update_news_values.full_text}"></textarea></td>
            {/if}
        </tr>

        <tr> 
            <td>Дата публикации</td>
            {if isset($update_news_values.date_publication)}
                <td> {$update_news_values.date_publication} </td>
                <td><input type="date" name="update_date" value="{$update_news_values.date_publication}"></td>
            {/if}
        </tr>

        <tr> 
            <td>Изображение статьи (в формате png):</td>
            {if isset($update_news_values.image_path)}
                <td> 
                    <img src="{$update_news_values.image_path|truncate_img_src}" width="400" height="220">
                </td>
                <td><input type="file" name="update_image" value=""/></td>
            {/if}
        </tr>

        <tr> 
            <td>Скрытая статья</td>
            {if isset($update_news_values.hiding)}
                <td> {$update_news_values.hiding} </td>
                <td><input type="checkbox" name="update_hiding"/></td>
            {/if}
        </tr>
        </table>
        <br>
        <input type="submit" name="mode" value="Сохранить"><br><br><br> 
    </form>

    <form method="post" action="index.php">
        <input type="submit" name="mode" value="Выйти из административного интерфейса"><br><br>
    </form>
</div>
