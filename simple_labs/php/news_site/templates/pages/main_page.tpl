<!doctype html>
<html lang='ru'>
<head>
    {include file='head.tpl'}
</head>

<body>
    <div>
        {include file='header.tpl'}
    </div>

    <div>
        {if $role == 'admin'}
            {if !isset($news_values)} {$news_values = ''} {/if}
            {include file='admin/main.tpl' news_list=$news update_news_values=$news_values}
        {elseif $role == 'no_login_admin'}
            {include file='admin/login.tpl'}
        {elseif $role == 'user'}
            {include file='user/main.tpl'}
        {elseif $role == 'user_view'}
            {include file='user/view_news.tpl'}
        {/if}
    </div>

    <div>
        {include file='footer.tpl'}
    </div>
</body>
</html>
