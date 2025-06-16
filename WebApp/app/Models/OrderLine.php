<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasOne;
use function PHPUnit\Framework\returnArgument;

class OrderLine extends Model
{
    public function Pizza() : HasOne
    {
        return $this->hasOne(Pizza::class);
    }
}
