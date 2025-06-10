<?php

use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});

Route::get('/cart', function () {
    return view('cartpage');
});
Route::get('/menu', function () {
    return view('menupage');
});
Route::get('/order', function () {
    return view('orderpage');
});

Route::get('/checkout', function () {
    return view('checkoutpage');
});