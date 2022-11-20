<div>
    <table width="100%">
        <tr>
            <td> <img src="./src/images/The_Times_logo.png"> </td>
            <td> 
                {if isset($date_now)}
                   <h3> Текущая дата {$date_now} </h3>
                {/if} 
            </td>
            <td>
                <form method="post" action="index.php">
                    <input type="submit" name="mode" value="Главная страница">
                    <input type="submit" name="mode" value="Администратор">
                </form>
            </td>
        </tr>
    </table>  

    <br> <br> <br>
</div>
