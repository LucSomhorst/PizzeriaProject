<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Database\Eloquent\Factories\HasFactory;

class Order extends Model
{
        use HasFactory;

    protected $fillable = [
        'date',
        'status'
    ];
    public function OrderLines() : HasMany
    {
        return $this->hasMany(OrderLine::class);
    }

    public function CalculatePrice()
    {
        $price = 0;
        foreach($this->OrderLines as $orderline)
        {
            $price = $price + $orderline->price();
        }
        return $price;
    }
}
