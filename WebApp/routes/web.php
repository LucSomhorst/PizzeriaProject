<?php

use App\Http\Controllers\OrderController;
use App\Http\Controllers\ShopController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});
Route::get('/cart', function () {
    return view('cartpage');
});

Route::get('/home', function () {
    return view('homepage');
});
Route::get('/checkout', function () {
    return view('checkoutpage');
});

route::get('/menu', [ShopController::class, 'index']);
route::post('/menu/{id}', [ShopController::class,'addItem']);
Route::resources(
    ['order' => OrderController::class]
);