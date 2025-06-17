<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\BelongsToMany;
use Illuminate\Database\Eloquent\Relations\HasMany;
use phpDocumentor\Reflection\Types\Integer;


class Pizza extends Model
{
        use HasFactory;

    protected $fillable = [
        'name',
    ];

    public function Orderlines() : HasMany {
        return $this->hasMany(OrderLine::class);
    }

    public function Ingredients() : BelongsToMany{
        return $this->BelongsToMany(Ingredient::class);
    }

    public function CalculatePrice()
    {
        $price = 0;
        $ingredients = $this->Ingredients;

        if ($ingredients->isEmpty()) {
            return 0;
        }

        foreach ($ingredients as $ingredient) {
            $price += $ingredient->price;
        }

        return $price;
    }

}
