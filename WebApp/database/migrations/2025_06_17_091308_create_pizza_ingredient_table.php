<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
public function up(): void
{
    Schema::create('ingredient_pizza', function (Blueprint $table) {
        $table->foreignId('ingredient_id')->constrained()->onUpdate('cascade')->onDelete('cascade');
        $table->foreignId('pizza_id')->constrained()->onUpdate('cascade')->onDelete('cascade');
        $table->timestamps();

        $table->primary(['ingredient_id', 'pizza_id']); // Composite primary key
    });
}

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('ingredient_pizza');
    }
};
