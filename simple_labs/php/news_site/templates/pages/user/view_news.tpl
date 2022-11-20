<div>
    <h2 align="middle"> {$view_news_values.heading} </h2>

    <table style="margin: auto;">
        <tr width="400px">
            <td rowspan="2"> <img src="{$view_news_values.image_path|truncate_img_src}" width="400px" height="220px"> </td>
            <td> {$view_news_values.full_text} </td>
        </tr>

        <tr>
            <td> Дата публикации: {$view_news_values.date_publication} </td>
        </tr>
    </table>
</div>
