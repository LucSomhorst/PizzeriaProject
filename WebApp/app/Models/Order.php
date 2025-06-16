<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;
use function PHPUnit\Framework\returnArgument;

class Order extends Model
{
    public function OrderLine() : HasMany
    {
        return $this->hasMany(OrderLine::class);
    }
}
