<?php

namespace App\Http\Controllers;

use App\Models\Pizza;
use Illuminate\Http\Request;
use function PHPUnit\Framework\returnArgument;

class ShopController extends Controller
{
    public function Index()
    {
        $pizzas = Pizza::all();
        return view('/menupage', ['pizzas' => $pizzas]);
    }
}
