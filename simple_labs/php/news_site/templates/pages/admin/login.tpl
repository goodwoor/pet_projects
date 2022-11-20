<div> 
    <form method="post" action="index.php">
        <h3>Форма входа</h3>

        <input type="text" name="username" placeholder="Логин" required><br><br>
        <input type="password" name="passw" placeholder="Пароль" required><br><br>
        <input type="submit" name="mode" value="Вход"><br><br>
        Запомнить данные входа: <input type="checkbox" name="remember"><br><br>
        {if isset($error_login)}
            Ошибка: {$error_login}
            <br><br>
        {/if}
    </form>

    <div>
        <p> 
            Подсказка: логин = "master", пароль = "chief"
        </p>
    <div>
</div>
