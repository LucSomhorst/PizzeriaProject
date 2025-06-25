<?php

namespace App\Http\Controllers;
use App\Models\Pizza;
use Illuminate\Http\Request;

class CartController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $cart = session('cart');
        return view('cartpage') ;
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $name = $request->input('name');
        $size = $request->input('size');
        $amount = $request->input('amount', 1);
        $pizzaId = $request->input('id');

        // Unique key for the cart item
        $itemname = $name . '-' . $size;

        // Get existing cart from session
        $cart = session()->get('cart', []);

        // If item already exists, increment amount
        if (isset($cart[$itemname])) {
            $cart[$itemname]['amount'] += $amount;
        } else {
            // Add new item
            $cart[$itemname] = [
                'pizza' => Pizza::find($pizzaId),
                'size' => $size,
                'amount' => $amount,
            ];
        }

        // Save back to session
        session(['cart' => $cart]);
        return redirect()->route('home')->with('success', 'Item added to cart!');
    }

        /**
     * Remove the specified resource from storage.
     */
    public function remove(string $itemname)
    {
        // Get existing cart from session
        $cart = session()->get('cart', []);

        // If item already exists, remove
        if (isset($cart[$itemname])) {
            unset($cart[$itemname]);
        }
    }

    /**
     * Display the specified resource.
     */
    public function show(string $itemname)
    {
        
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $itemname)
    {
        $name = $request->input('name');
        $size = $request->input('size');
        $amount = $request->input('amount', 1);

        // Get existing cart from session
        $cart = session()->get('cart', []);

        // If item already exists, increment amount
        if (isset($cart[$itemname])) {
            $cart[$itemname] = [
                'name' => $name,
                'size' => $size,
                'amount' => $amount,
            ];
        }

        // Save back to session
        session(['cart' => $cart]);
        
        return redirect()->route('home')->with('success', 'Item updated!');
    }


}
