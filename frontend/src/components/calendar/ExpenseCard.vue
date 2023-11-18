<template>
    <div :style="{
        backgroundColor: expenseCardStyle.background,
        color: expenseCardStyle.text,
    }" class="expense-card">
        <span class="expense-card-name">
            {{ props.name }}
        </span>
        <span class="expense-card-amount">
            {{ props.amount }}
        </span>
    </div>
</template>

<script setup lang="ts">
import { useStyleStore } from '../../stores/style';

const expenseCardStyle = useStyleStore().sectionStyles.calendar.expenseCards

const props = defineProps({
    amount: {
        type: Number,
        required: true
    },
    name: {
        type: String,
        required: true
    },
})

</script>

<style scoped>
.expense-card {
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    border-radius: 4px;
    font-size: small;
    margin-top: 1px;
    padding: 2px;
}

.expense-card-amount {
    font-weight: bolder;
}
</style>