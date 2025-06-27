<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use function PHPUnit\Framework\returnArgument;


class OrderLine extends Model
{
        use HasFactory;
        protected $table = 'orderlines';

    protected $fillable = [
        'size',
        'amount',
        'pizza_id',
        'order_id'
    ];
    public function Pizza(): BelongsTo
    {
        return $this->belongsTo(Pizza::class);
    }

    public function Order() : BelongsTo
    {
        return $this->belongsTo(Order::class);
    }

    public function CalculatePrice()
    {
        $price = $this->Pizza->CalculatePrice();
        switch ($this->size)
        {
            case 'small': $price *= 1; break;
            case 'medium' : $price *= 1.2; break;
            case 'large': $price *= 1.5; break;
        }
        return $price;
    }
}
