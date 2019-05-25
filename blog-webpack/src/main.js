//导入jquery
import $ from 'jquery'
//导入css样式表
import './css/index.css'


$(function () {

    $('li:odd').css('background','blue');       //偶数行
    // $('li:even').css('background','yellow');  //奇数行
    $('li:even').css('background',function () { 
        return '#'+'27ae60'
    })

})