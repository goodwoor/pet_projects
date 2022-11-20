<div>
    <h2 align="middle"> Лента новостей  </h2>   
        <table style="margin: auto;">
            {foreach from=$sort_news item=news_item}
                    <tr width="400px">
                        <td rowspan="3"> <img src="{$news_item.image_path|truncate_img_src}" width="400px" height="220px"> </td>
                        <td> <h3> {$news_item.heading} </h3> </td>
                    </tr>

                    <tr>
                        <td> {$news_item.annotation} </td>
                    </tr>

                    <tr>
                        <td> 
                            Дата публикации: {$news_item.date_publication} <br> <br>
                            <form method="post" action="index.php">
                                <input type="submit" name="mode" value="Читать полностью">
                                <input type="hidden" name="view_ID" value="{$news_item.ID}">
                            </form>  
                        </td>
                    </tr>

                    <tr height="30px"> </tr>
            {/foreach}
        </table>
        <br> <br>
</div>
